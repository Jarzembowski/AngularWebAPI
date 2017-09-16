app.controller('APIController', function ($scope, APIService) {

    
    getAll();

    function getAll() {
        var servCall = APIService.getSubs();
        servCall.then(function (d) {
            $scope.subscriber = d.data;
        }, function (error) {
            //$log.error('Oops! Something went wrong while fetching the data.')
        })
    }

    $scope.saveSubs = function () {

        console.log('saveSubs');
        var sub = {
            Email: $scope.email,
            SubscribeDate: new Date()
        };
        console.log(sub);
        var saveSubs = APIService.saveSubscriber(sub);
        saveSubs.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while saving the data.')
        })
    };

    $scope.makeEditable = function (obj) {
        obj.target.setAttribute("contenteditable", true);
        obj.target.focus();
    };

    $scope.updSubscriber = function (sub, eve) {
        sub.Email = eve.currentTarget.innerText;
        var upd = APIService.updSubscriber(sub);
        upd.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while updating the data.')
        })
    };

    $scope.dltSubscriber = function (subID) {
        var dlt = APIService.deleteSubscriber(subID);
        dlt.then(function (d) {
            getAll();
        }, function (error) {
            console.log('Oops! Something went wrong while deleting the data.')
        })
    };

    $scope.acessLog = function (id) {
        window.location.href = "/SubscriberForm/#!/subscribers/log/" + id;
        //$router.navigate('/information', { id: 42, type: 'wisdom', isUser: false });
    };

})