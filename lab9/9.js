let oldPart = document.getElementById('old-part');
let newPart = document.getElementById('new-part');
let operatorInserted = false;
let result_eq = false;

function clearDisplay() {
    oldPart.textContent = '';
    newPart.textContent = '0';
    operatorInserted = false;
}

function deleteDigit() {
    if (newPart.textContent.length > 1) newPart.textContent = newPart.textContent.slice(0, -1);
    else newPart.textContent = '0';
}

function appendNumber(number) {
    if (result_eq)
    {
        newPart.textContent = number;
        result_eq = false;
    }
    else if (newPart.textContent === '0') newPart.textContent = number;
    else newPart.textContent += number;
}

function appendDot() {
    if (result_eq) {
        newPart.textContent = '0.';
        result_eq = false;
    }
    else if (!newPart.textContent.includes('.')) newPart.textContent += '.';
}

function appendOperator(op) {
    if (!operatorInserted)
    {
        oldPart.textContent = newPart.textContent + op;
        newPart.textContent = '0';
        operatorInserted = true;
    }
    else
    {
        /* */
        //let expression = oldPart.textContent + ' ' + newPart.textContent;
        //let result = eval(expression);
        //oldPart.textContent = result;
        oldPart.textContent = oldPart.textContent.slice(0, -1);
        oldPart.textContent += op;
        /* */
        /*newPart.textContent = '0';*/

    }
}

function calculateResult() {
    let expression = oldPart.textContent + ' ' + newPart.textContent;
    let result = eval(expression);
    oldPart.textContent = '';
    newPart.textContent = result;
    operatorInserted = false;
    result_eq = true;

}
