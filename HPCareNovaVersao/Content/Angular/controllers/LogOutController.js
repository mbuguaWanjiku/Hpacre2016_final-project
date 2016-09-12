app.controller('logOutController', function ($scope, logOutService,$interval) {
    $scope.controllerName = "logOutController";
   
    logOutService.logOut().then(function () {
        $interval(function () {
            window.location = 'http://hpcare2016.com';


        }, 1000);
      

    });
});
app.service('logOutService',function($http){
  var service={}; 
   
  service.logOut =  function(){
      return $http.get("../Account/logOff");
  }
  return service;
});