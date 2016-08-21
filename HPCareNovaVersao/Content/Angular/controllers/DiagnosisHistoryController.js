app.controller("DiagnosisHistoryController", function ($scope, myService) {

    GetPatientDiseases();
    
    function GetPatientDiseases() {
        debugger;
        var getData = myService.getDiseases();
        debugger;
        getData.then(function (Patientdisease) {
            $scope.diseases = Patientdisease.data;         
            alert(Patientdisease.data);
        }, function () {
            alert('Error in getting records');
        });
    }

    $scope.DeactivateDisease = function (disease) {
        var getData = myService.DeactivateDisease(disease);
        getData.then(function (msg) {
            GetPatientDiseases();
            alert('Disease updated');
        }, function () {
            alert('Error in Deleting Record');
        });
    }

     GetDiagnosisHistory();
    //To Get All Records 
    function GetDiagnosisHistory() {
        debugger;
        var getData = myService.getPatientHistory();
        debugger;
        getData.then(function (diagnosisHistory) {
            $scope.diagnoses = diagnosisHistory.data;
        }, function () {
            alert('Error in getting records');
        });
    }

});

//    ///*********************************Diagnosis  History**********************************************/
//app.controller("DiagnosisHistoryController", function ($scope, myService) {
//    GetDiagnosisHistory();
//    //To Get All Records 
//    function GetDiagnosisHistory() {
//        debugger;
//        var getData = myService.getPatientHistory();
//        debugger;
//        getData.then(function (diagnosisHistory) {
//            $scope.diagnoses = diagnosisHistory.data;
//        }, function () {
//            alert('Error in getting records');
//        });
//    }
   
//});
//    /******************************Prescribe MCDT*********************************************************************/
    
//    //app.controller("MCDTController", function ($scope, $interval,myService) {
//    //    $scope.message = 0;
//    //    $scope.MCDTS = prescribedMCDTS;
//    //    $interval(function () {
    //        $scope.message++;
    //        $scope.MCDTS = prescribedMCDTS;
    //    }, 500);

    //    $scope.deleteMCDT = function (element) {
       
    //        prescribedMCDTS.splice(prescribedMCDTS.indexOf(element), 1);

    //    }
    //    $scope.saveMcdts = function () {
            
    //        var getData = myService.saveSelectedMCDT();
    //        getData.then(function (msg) {
    //            // GetPatientDiseases();
    //            alert('mcdt saved');
    //        }, function () {
    //            alert('Error in saving Record');
        
    //        });
    //    }
    //    $scope.home = function () {
   
    //        main();
          
    //    }

    //});

