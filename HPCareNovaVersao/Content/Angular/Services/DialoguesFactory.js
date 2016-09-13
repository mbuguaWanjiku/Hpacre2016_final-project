/// <reference path="../ModalViewsContent/modalLymphocyte.html" />
/// <reference path="../ModalViewsContent/modalLymphocyte.html" />


app.factory('alert', function ($uibModal) {

    var fac = {};
    fac.show = function (action, event) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalContent.html',
            controller: function () {
                var vm = this;
                vm.action = action;
                vm.event = event;
            },
            controllerAs: 'vm'
        });
    }

    fac.warning = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalWarning.html',
            controller: function () {
                var vm = this;
                vm.message = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.success = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalSuccess.html',
            controller: function () {
                var vm = this;
                vm.success = message;
            },
            controllerAs: 'vm'
        });
    }

    //fac.visitManager = function () {

    //    return $uibModal.open({
    //        backdrop: 'static',
    //        //keyboard: false,
    //        templateUrl: 'VisitManager.html',
    //        controller: function () {
    //            var vm = this;
             

    //        },
    //        controllerAs: 'vm'
    //    });
    //}
    fac.showObservation = function (obs) {
     
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalObservation.html',
            controller: function () {
                var vm = this;
                vm.observation = obs

            },
            controllerAs: 'vm'
        });
    }
  


















    fac.med = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalMed.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }


    fac.graphs = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalControlGraph.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.specificGraphs = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalSpecificControlGraph.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.updateAllergy = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalUpdateAllergy.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    return fac;
});
