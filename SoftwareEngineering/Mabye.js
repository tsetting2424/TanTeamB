/*if (EB != null) {


var eventArgs = new Object();
eventArgs.userName = $('#UserName').val();
eventArgs.password = $('#Password').val();

//raises the submit payment event
EB.RaiseEvent("CheckLogin", null, eventArgs);
}*/



/* EB.SubscribeEvent("CheckLogin", "checking user", checkLogin)

function checkLogin(sender, args) {
if (EB != undefined || EB != null) {
var eventArgs = new Object();
eventArgs.URL = "http://localhost:17461/Account/LoginAccount?UserName=" + args.userName + "&Password=" + args.password;
eventArgs.Container = "main";

//raises the get function that is on the consumer side that receives the html from the view and populates it in the caontainer sent to it
EB.RaiseEvent("get", this, eventArgs);
}
}*/