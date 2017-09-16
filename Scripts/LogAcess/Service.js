appLog.service("LogAcessService", function ($http) {

    this.getLogAcess = function (id) {
        return $http.get("../api/AcessLog/" + id);
        //return $http.get("api/Subscriber")
    };

});