app.service("APIService", function ($http) {

    this.getSubs = function () {
        return $http.get("../api/Subscriber")
    };
    
    this.saveSubscriber = function (sub) {
        return $http(
        {
            method: 'post',
            data: sub,
            url: '../api/Subscriber'
        });
    };

    this.updSubscriber = function (sub) {
        return $http(
        {
            method: 'put',
            data: sub,
            url: '../api/Subscriber/' + sub.Id
        })
    };

    this.deleteSubscriber = function (subID) {
        var url = '../api/Subscriber/' + subID;
        return $http(
        {
            method: 'delete',
            data: subID,
            url: url
        });
    }

    this.getLogs = function (id) {
        return $http.get("../api/AcessLog/" + id)
    };


});