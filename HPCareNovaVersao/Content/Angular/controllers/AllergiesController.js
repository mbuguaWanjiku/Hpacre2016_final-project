
app.factory('allergyDialogue', function ($uibModal, $http) {
    var fac = {};
    fac.updateAllergy = function (allergy) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalUpdateAllergy.html',
            controller: function () {
                var vm = this;
                vm.message = "debuggggg";
                vm.allergyUpdate = allergy;

                vm.updateAllergyDB = function (update) {
                    alert("loadededdddddddddd");
                    alert(JSON.stringify(update));
                    //  post(update);
                    var postData = post(update);
                    postData.then(function (dt) {
                        alert("passed")
                    }, function () {
                        alert('Error in getting records');
                    });
                }
            },
            controllerAs: 'vm'
        });
        function post(allergy) {
            var response = $http({
                method: "post",
                url: "../../../Patient/UpdateAllergies",
                data: allergy,
                dataType: "json",
            });
            alert("wwwwwwwwwwwwwwwwwww");
        }
    }

    return fac;
});