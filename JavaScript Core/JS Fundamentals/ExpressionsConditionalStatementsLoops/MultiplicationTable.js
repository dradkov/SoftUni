function solve(n) {
    console.log('<table border="1">');
    let firstRow = "<tr><th>x</th>";
    for (let index = 1; index <= n; index++) {
        firstRow += `<th>${index}</th>`
    }
    firstRow += "</tr>";
    console.log(firstRow);

    for (let row = 1; row <= n; row++) {
        let currentRow = `<tr><th>${row}</th>`;
        for (let index = 1; index <= n; index++) {
            currentRow += `<td>${index * row}</td>`
        }
        currentRow += "</tr>";
        console.log(currentRow);

    }
    console.log('</table>');
}
solve(5)