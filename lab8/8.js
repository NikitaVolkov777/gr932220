const items = new Map();
let counter = 0;

function render() {
    const container = document.getElementById('itemsContainer');
    container.innerHTML = '';

    items.forEach((value, id) => {
        const itemElement = createItemElement(id, value.key, value.value);
        container.appendChild(itemElement);
    });
}

function createItemElement(id, key, value) {
    const itemDiv = document.createElement('div');

    const keyInput = createInput(id, key, 'key');
    const valueInput = createInput(id, value, 'value');

    const moveUpButton = createButton('&uarr;', () => moveUp(id));
    const moveDownButton = createButton('&darr;', () => moveDown(id));
    const deleteButton = createButton('&times;', () => deleteItem(id));

    itemDiv.append(keyInput, valueInput, moveUpButton, moveDownButton, deleteButton);
    return itemDiv;
}

function createInput(id, value, type) {
    const input = document.createElement('input');
    input.value = value;
    input.addEventListener('change', () => editItem(id, input.value, type));
    return input;
}

function createButton(text, onClick) {
    const button = document.createElement('button');
    button.innerHTML = text;
    button.addEventListener('click', onClick);
    return button;
}

function addItem() {
    items.set(counter, { key: ``, value: `` });
    counter++;
    render();
}

function editItem(id, newValue, type) {
    if (items.has(id)) {
        const currentItem = items.get(id);
        if (type === 'key') {
            currentItem.key = newValue;
        } else if (type === 'value') {
            currentItem.value = newValue;
        }
        items.set(id, currentItem);
    }
}

function deleteItem(id) {
    if (items.has(id)) {
        items.delete(id);
        render();
    }
}

function moveUp(id) {
    const keys = Array.from(items.keys());
    const index = keys.indexOf(id);

    if (index > 0) {
        const previousId = keys[index - 1];
        const currentItem = items.get(id);
        const previousItem = items.get(previousId);

        items.set(id, previousItem);
        items.set(previousId, currentItem);

        render();
    }
}

function moveDown(id) {
    const keys = Array.from(items.keys());
    const index = keys.indexOf(id);

    if (index !== -1 && index < keys.length - 1) {
        const nextId = keys[index + 1];
        const currentItem = items.get(id);
        const nextItem = items.get(nextId);

        items.set(id, nextItem);
        items.set(nextId, currentItem);

        render();
    }
}

function printItems() {
    const resultContainer = document.getElementById('result');
    const result = [];

    items.forEach((value, id) => {
        result.push(`"${value.key}": "${value.value}"`);
    });

    resultContainer.innerText = `{ ${result.join(', ')} }`;
}

document.getElementById('addButton').addEventListener('click', addItem);
document.getElementById('saveButton').addEventListener('click', printItems);

render();