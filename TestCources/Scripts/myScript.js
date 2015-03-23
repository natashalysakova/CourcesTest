function LightUpCells(day, start, finish) {

    for (var i = 9; i < 18; i++) {
        var cell = $('.' + i + '_' + day);
        if (i >= start && i < finish) {
            cell.css('background-color', '#78b500');
        }
    }
}

function ClearTable() {
    for (var i = 9; i < 18; i++) {
        for (var j = 0; j < 6; j++) {
            var cell = $('.' + i + '_' + j);
            cell.css('background-color', '#ffffff');
        }
    }
}