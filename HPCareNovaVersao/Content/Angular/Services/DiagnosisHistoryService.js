app.service("myService", function ($http) {

    //get All  patient diseases
    this.getDiseases = function () {
      alert("getdisesas")
        return $http.get("../Diagnosis/GetPatientActiveDisease");
    };

  

    //Deactivating patient disease
    this.DeactivateDisease = function (disease) {
        var response = $http({
            method: "post",
            url: "../Diagnosis/DeactivateDisease",
            data: JSON.stringify(disease),
            dataType: "json",      
        });
        alert(disease +"called");
        return response;
    }


    /****************************Diagnosis history*****************************/
   
    this.getPatientHistory = function () {
        return $http.get("../Diagnosis/GetPatientDiagnosisHistoryJson");
    };



/********************prescribe MCDT**********************************************/
this.saveSelectedMCDT = function () {

            var response = $http({
                method: "post",
                url: "../../../MCDTs/PrescribeMCDT",
             //   url: "../../MCDTs/PrescribeMCDT",
                data: JSON.stringify(prescribedMCDTS),
                dataType: "json",
            });
         alert(response);
            return response;
};
//this.savePrescribedMedication = function (PrescribedMed) {

//    var response = $http({
//        method: "post",
//        url: "../../Medication/PrescribeMedication",
//        //   url: "../../MCDTs/PrescribeMCDT",
//        data: JSON.stringify(PrescribedMed),
//        dataType: "json",
//    });
//    alert(response);
//    return response;
//};


        });