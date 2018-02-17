function addItem() {
    let newTextItem = document.querySelector('#newItemText');
    let itemValue = document.getElementById('newItemValue');

    let dropDown = document.getElementById('menu');
    let option = document.createElement('option');

   option.value = itemValue.value;
   option.text = newTextItem.value;

    dropDown.appendChild(option);

    newTextItem.value= '';
    itemValue.value = '';
}


