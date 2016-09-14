app.controller("loadIndexCTR", function ($state) {
    var vm = this;
    vm.loadProfile= function(){
        $state.go('myInfo')
}
  vm.labIndex= function(){
        $state.go('labTec')
}
});