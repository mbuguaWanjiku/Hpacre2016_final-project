/// <reference path="page_1.html" />
/// <reference path="page_3.html" />
var app = angular.module("myApp", ['ui.router']);

app.config(function ($stateProvider, $urlRouterProvider) {

    $urlRouterProvider.when("", "/page1");

    //$stateProvider
    //   .state("page1", {
    //       url: "/page1",
    //       templateUrl: "page_1.html"
    //   })
    //   .state("page2", {
    //       url:"/page2",
    //       templateUrl: "page_2.html"
    //   })
    //   .state("page3", {
    //       url:"/page3",
    //       templateUrl: "/Home/DashboardClinic2"
    //   });


    $stateProvider
    .state("page1", {
           url: "/page1",
           templateUrl: "page_2.html"
       })
         .state("page3", {
           url:"/page3",
           templateUrl: "/Home/DashboardClinic2"
       })

      .state("page4", {
          url: "/searchPatient",
          templateUrl: "/Home/SearchPatient"
      })

      .state("page5", {
          url: "/ClassifyDisease",
          templateUrl: "Home/About"
      })
      .state("page2", {
          url: "/UpdateDiseaseStatus",
          templateUrl: "/Diagnosis/UpdateDiseaseStatusResult"
      })
      .state("DiagnosisHistory", {
          url: "/DiagnosisHistory",
          templateUrl: "/Diagnosis/GetPatientDiagnosisHistory"
      });
});