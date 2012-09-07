var EB = {
    SubscribeEvent: function (eventName, objectName, functionPointer) {
        if (this._eventArray === undefined) {
            this._eventArray = new Array();
        }
        var found = false;
        $.each(this._eventArray, function (index, value) {
            if (value.EventName === eventName && value.ObjectName === objectName) {
                value.FunctionPointer = functionPointer;
                found = true;
            }
        });
        if (!found) {
            var newItem = new Object();
            newItem.EventName = eventName;
            newItem.ObjectName = objectName;
            newItem.FunctionPointer = functionPointer;
            this._eventArray.push(newItem);
        }
        return (!found);
    },
    RaiseEvent: function (eventName, sourceObject, eventArgs) {
        if (this._eventArray !== undefined) {
            $.each(this._eventArray, function (index, value) {
                if (value.EventName === eventName && value.FunctionPointer !== undefined) {
                    value.FunctionPointer(sourceObject, eventArgs);
                }
            });
        }
    }
}