app.controller("homeController", function ($scope, $state, HomeService, alert) {

    $scope.Search = "";
    $scope.getDetails = function () {
        var res = document.getElementById("searchPatient").value;
        var getData = HomeService.SearchPatient(res);
        getData.then(function (patient) {
            $scope.SearchRes = patient.data;
            $state.go('consultPatientInfo')
        }, function () {
            alert.warning('Error in getting records');
        });
    }

    $scope.visitManagerModal = function () {
        alert.visitManager();
    }

});


app.factory('HomeService', function ($http) {
    var fac = {};

    fac.SearchPatient = function (id) {
        alert(id);
        return $http.get('../Home/Search?search=' + id)

    }


    return fac;
});