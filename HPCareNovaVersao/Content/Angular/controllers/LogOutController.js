app.controller('logOutController', function ($scope,$window, logOutService) {
    $scope.controllerName = "logOutController";
   
    logOutService.logOut().success(function () {
       alert("success");


    });
});
app.service('logOutService',function($http){
  var service={}; 
   
  service.logOut =  function(){
      return $http.get("../Account/logOff");
  }
  return service;
});