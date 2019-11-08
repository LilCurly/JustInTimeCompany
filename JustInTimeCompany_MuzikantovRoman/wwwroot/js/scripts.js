$(document).ready(function () {
        $(".dropdown-button").click(function () {
            let index = $(".dropdown-button").index(this);
            if ($(".dropdown-content")[index].style.height == "0px") {
                $(".dropdown-content")[index].style.height = "auto";
                $(".dropdown-content")[index].style.opacity = "1";
                $(".dropdown-content")[index].style.padding = "15px";
                $(".dropdown-content")[index].style.visibility = "visible";
                $(".fa-arrow-down")[index].classList.add("fa-rotate-180");
                let items = $(".dropdown-content")[index];
                for (let i = 0; i < items.childElementCount; i++) {
                    for (let j = 0; j < items.children[i].childElementCount; j++) {
                        items.children[i].children[j].style.height = "auto";
                    }
                }
            } else {
                $(".dropdown-content")[index].style.visibility = "hidden";
                $(".dropdown-content")[index].style.height = "0";
                $(".dropdown-content")[index].style.padding = "0";
                $(".dropdown-content")[index].style.opacity = "0";
                $(".fa-arrow-down")[index].classList.remove("fa-rotate-180");
                let items = $(".dropdown-content")[index];
                for (var i = 0; i < items.childElementCount; i++) {
                    for (var j = 0; j < items.children[i].childElementCount; j++) {
                        items.children[i].children[j].style.height = "0";
                    }
                }
            }
        })
    })