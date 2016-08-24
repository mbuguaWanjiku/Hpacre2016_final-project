
var app = angular.module('myApp', ['mwl.calendar', 'ngAnimate', 'ui.bootstrap', 'colorpicker.module','ui.router'  ]);

  app.filter('jsonDate', ['$filter', function ($filter) {
    return function (input, format) {
        return (input) 
               ? $filter('date')(parseInt(input.substr(6)), format) 
               : '';
    };

     
  }]);

 
  app.run(function($rootScope){

    $rootScope
        .$on('$stateChangeStart', 
            function(event, toState, toParams, fromState, fromParams){ 
                $("#ui-view").html("");
                $(".page-loading").removeClass("hidden");
        });

    $rootScope
        .$on('$stateChangeSuccess',
            function(event, toState, toParams, fromState, fromParams){ 
                $(".page-loading").addClass("hidden");
        });

});
