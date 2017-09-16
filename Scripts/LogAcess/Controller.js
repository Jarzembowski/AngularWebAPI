app.config(['$routeProvider',
    function ($routeProvider) {
        $routeProvider
            .when('/log/', {
                templateUrl: 'logacess.html',
                controller: 'LogAcessController',
                resolve: resolve
            })           
    }
]);


appLog.controller('LogAcessController', function ($scope, LogAcessService, $routeParams) {
    getAll();

    function getAll() {
        console.log('params - ' + $routeParams.id);

        /*
        var servCall = LogAcessService.getLogAcess($routeParams['id']);
        
        servCall.then(function (d) {
            $scope.logs = d.data;
        }, function (error) {
   
        })
        */
    }

   

})