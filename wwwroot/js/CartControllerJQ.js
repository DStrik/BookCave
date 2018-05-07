var incBtn = document.getElementById("incrementQty");
var decBtn = document.getElementById("decrementQty");
var counter = document.getElementById("qty");
counter.innerHTML = 1;
incBtn.onclick = function(){
    counter.innerHTML++;
}
decBtn.onclick = function(){
    counter.innerHTML--;
}