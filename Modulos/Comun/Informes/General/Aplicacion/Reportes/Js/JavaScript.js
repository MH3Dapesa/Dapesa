function ValidarEspacio(e, campo) {
    key = e.keyCode ? e.keyCode : e.which;
    if (key == 32) { return false; }
}

function MasFiltros() {
    var Encabezado = document.getElementById("btnMasFiltros").innerHTML;
    if (Encabezado == "Mas Filtros") {
        var x = document.getElementsByClassName("FiltrosOpcionales");
        var i;
        for (i = 0; i < x.length; i++) {
            x[i].style.display = "block";
        }
        document.getElementById("btnMasFiltros").innerHTML = "Menos Filtros";
        document.getElementById("btnMasFiltros").style.backgroundColor = "#c38938";
    }
    else {
        var x = document.getElementsByClassName("FiltrosOpcionales");
        var i;
        for (i = 0; i < x.length; i++) {
            x[i].style.display = "none";
        }
        document.getElementById("btnMasFiltros").innerHTML = "Mas Filtros";
        document.getElementById("btnMasFiltros").style.backgroundColor = "#3872c3";
    }
}
    
function onCalendarShown1() {

    var cal = $find("Calendario1");
    cal._switchMode("months", true);

    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", Llamar1);
            }
        }
    }
}

function onCalendarHidden1() {
    var cal = $find("Calendario1");
    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", Llamar1);
            }
        }
    }

}

function Llamar1(eventElement) {
    var target = eventElement.target;
    switch (target.mode) {
        case "month":
            var cal = $find("Calendario1");
            cal._visibleDate = target.date;
            cal.set_selectedDate(target.date);
            cal._switchMonth(target.date);
            cal._blur.post(true);
            cal.raiseDateSelectionChanged();
            break;
    }
}

function onCalendarShown2() {

    var cal = $find("Calendario2");
    cal._switchMode("months", true);

    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", Llamar2);
            }
        }
    }
}

function onCalendarHidden2() {
    var cal = $find("Calendario2");
    if (cal._monthsBody) {
        for (var i = 0; i < cal._monthsBody.rows.length; i++) {
            var row = cal._monthsBody.rows[i];
            for (var j = 0; j < row.cells.length; j++) {
                Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", Llamar2);
            }
        }
    }

}

function Llamar2(eventElement) {
    var target = eventElement.target;
    switch (target.mode) {
        case "month":
            var cal = $find("Calendario2");
            cal._visibleDate = target.date;
            cal.set_selectedDate(target.date);
            cal._switchMonth(target.date);
            cal._blur.post(true);
            cal.raiseDateSelectionChanged();
            break;
    }
}
