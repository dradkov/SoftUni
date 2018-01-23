function calendar(arr) {

    let [day, month, year] = arr.map(Number);
    let html = '<table>\n';

    html += '<tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n';

    let currentDay = new Date(year, month - 1, 1);

    if (currentDay.getDay() !== 0) {
        currentDay = new Date(year, month - 2, new Date(year, month - 1, 0).getDate() - currentDay.getDay() + 1);
    }

    let nextMonth = new Date(year, month, 1).getMonth();
    let previousMonth = new Date(year, month - 2, 1).getMonth();

    while(currentDay.getMonth() !== nextMonth || currentDay.getDay() !== 0) {
        if(currentDay.getDay() === 0){
            html += ' <tr>';
        }

        if(currentDay.getMonth() === previousMonth) {
            html += `<td class="prev-month">${currentDay.getDate()}</td>`;
        } else if(currentDay.getMonth() === nextMonth) {
            html += `<td class="next-month">${currentDay.getDate()}</td>`;
        } else if(currentDay.getDate() === day
            && currentDay.getMonth() === month - 1) {
            html += `<td class="today">${currentDay.getDate()}</td>`;
        } else {
            html += `<td>${currentDay.getDate()}</td>`;
        }

        if (currentDay.getDay() === 6) {
            html += '</tr>\n';
        }

        currentDay.setDate(currentDay.getDate() + 1);
    }

    html += "</table>";
    return html;
}