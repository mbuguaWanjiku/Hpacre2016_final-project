
var app = angular.module('myApp', ['mwl.calendar', 'ngAnimate', 'ui.bootstrap', 'colorpicker.module', 'ui.router', 'ngLoadingSpinner']);

    app.filter('jsonDate', ['$filter', function ($filter) {
        return function (input, format) {
            return (input) 
                   ? $filter('date')(parseInt(input.substr(6)), format) 
                   : '';
        };

     
    }]);

  app.run(function($rootScope) {
      $rootScope.subsequentVisit = 'false'
            // $rootScope.valid=(patient.Address === null || patient.MaritalStatus === null || patient.Gender === null);           
        
    })
   
    app.run(function($rootScope) {
        $rootScope.filledFields = function (patient) {
            $rootScope.subsequentVisit =(patient.Address !== null && patient.MaritalStatus !== null && patient.Gender !== null);           
        }
    })
   
    