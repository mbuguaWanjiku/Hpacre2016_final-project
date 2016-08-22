app.config(function ($stateProvider, $urlRouterProvider) {
    //$urlRouterProvider.when("", "");
    //$urlRouterProvider.otherwise('/');
    $stateProvider
     //.state("VisitManager", {
     //    url: "VisitManager.html",
     //    templateUrl: "VisitManager.html"
     //})

       .state("searchPatient", {
           url: "/searchPatient",

           templateUrl: "../Home/SearchPatient"
       })

       .state("prescribeMCDT", {
           url: "/prescribeMCDT",
           templateUrl: "../MCDTs/PrescribeMCDT"
       })

         .state("regularExamsHistory", {
             url: "/RegularExamsHistory",
             templateUrl: "../RegularExamsHistory/GetRegularExamsHistory"
         })

       .state("classifyDisease", {
           url: "/classifyDisease",
           templateUrl: "../Diagnosis/ClassifyDisease_CID"
       })

       .state("updateDiseaseStatus", {
           url: "/UpdateDiseaseStatus",
           templateUrl: "../Diagnosis/UpdateDiseaseStatusResult"
       })

       .state("diagnosisHistory", {
           url: "/diagnosisHistory",
           templateUrl: "../Diagnosis/GetPatientDiagnosisHistory"
       })

        .state("prescribeMedication", {
            url: "/prescribeMedication",
            templateUrl: "../Medication/PrescribeMedication"
        })

         .state("medicationHistory", {
             url: "/medicationHistory",
             templateUrl: "../Medication/PrescribeMedicationHistory"
         })


    // ****************** Graphs ****************************//
    .state("mcdtResults", {
        url: "/MonitorizationGraphs",
        templateUrl: "../LabExams/MonitorizationGraphs"
    })

      .state("mcdtSpecificResults", {
          url: "/SpecificGraphMonitorization",
          templateUrl: "../LabExams/SpecificGraphMonitorization"
      })

    // **************** LabTec Template ********************//
    .state("addLabResults", {
        url: "/addLabResults",
        templateUrl: "../LabExams/ListMcdts",
    })

    //**************** Patient Info ************************//

    .state("addPatientInfo", {
        url: "/patientInfo",
        templateUrl: "../Patient/AddPatientInformation"
    })

    .state("consultPatientInfo", {
        url: "/consultPatientInfo",
        templateUrl: "../Patient/ListPatientInformation"
    })

    .state("clinicProfile", {
        url: "/clinicProfile",
        templateUrl: "../Staffs/ListClinicInformation"
    })

    .state("labTecProfile", {
        url: "/labTecProfile",
        templateUrl: "../Staffs/ListLabTecInformation"
    })

    //*********** Treatment Plan **************//
    .state("createTreatmentPlan", {
        url: "/createTreatmentPlan",
        templateUrl: "../TreatmentPlans/Index"
        //resolve: { title: 'TreatmentPlan' },
        //controller: function ($scope, title) {
        //    $scope.title = title;
        //},
        //onEnter: function (title) {
        //    if (title) { alert("enter"); }
        //},
        //onExit: function (title) {
        //    if (title) { alert("exits"); }
        //}
    })
    .state("consultTreatmentPlan", {
        url: "/TreatmentPlanMed",
        templateUrl: "../Content/TreatmentPlan/TreatmentPlanMed.html"
    })

     // *************** Patient Template ******************//

    .state("patientProfilePage", {
        url: "/patientProfilePage",
        templateUrl: "../Patient/PatientProfilePage"
    })

    .state("patientTreatmentPlan", {
        url: "/patientTreatmentPlan",
        templateUrl: "../Patient/PatientTreatmentPlan"
    })

    .state("patientMcdts", {
        url: "/patientMcdts",
        templateUrl: "../Patient/PatientMcdts"
    })

    .state("patientDiseaseHistory", {
        url: "/patientDiseaseHistory",
        templateUrl: "../Patient/PatientDiseaseHistory"
    })

    .state("patientMedications", {
        url: "/patientMedications",
        templateUrl: "../Patient/PatientMedications"
    })









});

//app.run(['$state', function ($state) {
//    $state.transitionTo('VisitManager');
//}])
