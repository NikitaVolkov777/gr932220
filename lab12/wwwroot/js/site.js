function calculate() {
    const operand1 = document.getElementById("operand1").value;
    const operator = document.getElementById("operator").value;
    const operand2 = document.getElementById("operand2").value;

    fetch('/ParsingModel/Calculate', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ operand1: parseInt(operand1), Operator: operator, operand2: parseInt(operand2) })
    })
        .then(response => response.json())
        .then(data => {
            document.getElementById("result").innerHTML = `<p>${data.result} ЫЫЫЫ</p> `;
            document.getElementById("calcForm").reset(); // Очищает форму после отправки
        })
        .catch(error => console.error('Error:', error));
}