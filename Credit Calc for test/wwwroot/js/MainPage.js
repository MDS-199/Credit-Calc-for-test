document.getElementById("Form1Off").addEventListener("change", function () {
    var isChecked = this.checked;
    var form1 = document.getElementById("form1");
    var form2 = document.getElementById("form2");

    if (isChecked) {
        form1.classList.add("hidden");
        form2.classList.remove("hidden");
    } else {
        form1.classList.remove("hidden");
        form2.classList.add("hidden");
    }
});


//Метод из гидры
/*
function ClickCheckBox() {

    var checkBox = document.getElementById("Form1Off");
    var Form1 = document.getElementById("form1");
    var Form2 = document.getElementById("form2");



    Form1.style.opacity = "1";
    switch (Form2) {
        case null: break;
        default: Form2.style.opacity = "0";
    }



    // Если кнопка нажата, то показывать форму 2
    if (checkBox.checked == true) {
        Form1.style.opacity = "0";
        switch (Form2) {
            case null: break;
            default: Form2.style.opacity = "1";
        }

    }
    else {
        Form1.style.opacity = "1";
        switch (Form2) {
            case null: break;
            default: Form2.style.opacity = "0";
        }

    }
}*/