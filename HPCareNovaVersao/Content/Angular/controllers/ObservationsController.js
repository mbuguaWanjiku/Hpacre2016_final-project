
app.controller("observationController", function ($scope,alert, observationService) {
    var vm = this;
    vm.subject;
    vm.observationBody;
    vm.archive = [];
    $scope.rowLimit = 20;
    $scope.sortColumn = "Date";
    vm.setForm = function (form) {
        vm.obsForm = form;
    }
    vm.saveToBD = function () {
        var arrayObsev = [];
        arrayObsev.push(vm.subject);
        arrayObsev.push(vm.observationBody);
        var posting = observationService.saveObservation(arrayObsev);
        posting.then(function (dt) {
            alert.success("posted observation")
        },
           function (error) {
               alert.warning("error posting data")
           });
    }    
        var getData = observationService.GetObservationsHistory();
        getData.then(function (dt) {    
            for (var i = 0; i < dt.data.length; i++) {
                if (dt.data[i]) {
                    vm.archive.push(dt.data[i]);
                }
            }       
            ////alert(JSON.stringify(vm.archive[0].Date))
        }, function (error) {
            alert("error in obtaining drug category");

        });
        vm.GetObservation = function (observation) {
            
            var getData = observationService.GetObservation(observation.observationID);
            getData.then(function (obs) {
               
                alert.showObservation(obs.data[0]);
              
            }, function () {
                alert.warning('Error in getting records');
            });
        }
});


