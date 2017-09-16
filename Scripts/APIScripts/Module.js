var app;
(function () {
    app = angular.module("AppModule", ['ngRoute']);


    app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider.
            when('/subscribers', {
                templateUrl: '/partials/teste.html',
                controller: 'APIController'
            })
        .when('/subscribers/log/:id', {
            templateUrl: '/partials/logs.html',
            controller: 'LogController'
        })
        .otherwise({ redirectTo: '/asdasdasd' });
    }
    ]);

})();