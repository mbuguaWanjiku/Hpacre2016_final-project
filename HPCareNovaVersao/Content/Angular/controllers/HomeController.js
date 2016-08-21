app.controller("SearchPatient", function ($scope,HomeService) {

    $scope.Search = "";

    
    
    $scope.getDetails = function () {
        var res = document.getElementById("searchPatient").value;
       
        HomeService.SearchPatient(res);
    }

});


app.factory('HomeService', function ($http) {
    var fac = {};

    fac.SearchPatient = function (id) {
        alert(id);
        return $http.get('../Home/SearchPatient?search='+ id)
        alert("passed");
    }
    return fac;
});