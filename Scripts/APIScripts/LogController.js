app.controller('LogController', ['$route', '$routeParams', '$location', 'APIService','$scope',
function ($route, $routeParams, $location,APIService,$scope) {
    
    getAll($routeParams.id);

    function getAll(id) {
        var servCall = APIService.getLogs(id);
        servCall.then(function (d) {
            $scope.logs = d.data;
        }, function (error) {
            //$log.error('Oops! Something went wrong while fetching the data.')
        })
    }



}])
