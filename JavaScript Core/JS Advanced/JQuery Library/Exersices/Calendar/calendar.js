function calendar (calendarDate) {
    let [day, month, year] = calendarDate
    let date = new Date(year, month - 1, 0)
    let daysInMonth = new Date(year, month, 0).getDate()
   
    let monthNames = [
      'January', 'February', 'March', 'April', 'May', 'June', 'July',
      'August', 'September', 'October', 'November', 'December']
   
    let root = $('#content')
    let tableBody = $('<tbody>')
   
    tableBody.append($('<tr>')
      .append($('<th>').text('Mon'))
      .append($('<th>').text('Tue'))
      .append($('<th>').text('Wed'))
      .append($('<th>').text('Thu'))
      .append($('<th>').text('Fri'))
      .append($('<th>').text('Sat'))
      .append($('<th>').text('Sun')))
   
    date.setDate(date.getDate() - date.getDay())
   
    for (let row = 0; row < 4; row++) {
      let tableRow = $('<tr>')
      tableBody.append(tableRow)
   
      for (let col = 0; col < 7; col++) {
        date.setDate(date.getDate() + 1)
   
        if (date.getMonth() === month - 1) {
          if (date.getDate() === day) {
            tableRow.append($('<td>').addClass('today').text(`${date.getDate()}`))
          } else {
            tableRow.append($('<td>').text(`${date.getDate()}`))
          }
        } else {
          tableRow.append($('<td>'))
        }
      }
   
      if (date.getMonth() === month - 1 &&
        row === 3 &&
        daysInMonth > date.getDate()) {
        row--
      }
    }
   
    let table = $('<table>')
      .append($('<caption>').text(`${monthNames[month - 1]} ${year}`))
      .append(tableBody)
   
    root.append(table)
  }