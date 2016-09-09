
app.factory('searchDialogue', function ($uibModal, $http, $state, $interval) {
    var fac = {};
    fac.exist= function(valor){
        return 'True';
    }
    fac.searchPatient = function () {

        return $uibModal.open({
            backdrop: 'static',
            templateUrl: '../Content/Angular/ModalViewsContent/ModalSearchPatient.html',
            controller: function () {
                var vm = this;
                vm.patientExist = fac.exist();
          
                fac.getPatient = function () {
                  
                    
                    return $http.get('../Home/Search?search=' + vm.search)
                }

            },
            controllerAs: 'vm',

        }).closed.then(function () {

            var getData = fac.getPatient();
            getData.then(function (response) {
                fac.exist(response.data);
                if (response.data === 'True') {

                    fac.visitManager();
                } else {
                    alert("patient don't exist")
                    fac.searchPatient();
                }

            }, function () {
                alert('Error in getting records');
            });

        }, function () {
           
            alert("dismiss")
        });;
    }

    fac.visitManager = function () {

        return $uibModal.open({
            backdrop: 'static',
            //keyboard: false,
            templateUrl: 'VisitManager.html',
            controller: function () {
                var vm = this;
                vm.firstVisit = function () {
                    $state.go('addPatientInfo');
                }
                vm.subsequenteVisit = function () {

                    $state.go('consultPatientInfo')
                }
            },
            controllerAs: 'vm'

        });

    }














    return fac;
});