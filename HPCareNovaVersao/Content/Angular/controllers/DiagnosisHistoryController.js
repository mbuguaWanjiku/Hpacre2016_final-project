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

