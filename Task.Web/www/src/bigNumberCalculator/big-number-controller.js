(function BigNumberController(){
    angular.module("app").controller("BigNumberCtrl" , Controller);

    Controller.$inject = ["numberService"];
    function Controller(numberService){
        var vm = this;
        vm.addNumbers = sum;
        vm.fetchLogs = fetchLogs;
        vm.number1 = "";
        vm.number2 = "";
        vm.result = "";
        vm.logs = "";
        vm.error = "";

        /** Private Functions */
        function fetchLogs(){
            var promise = numberService.getLogs();
            promise.then(function(response){
                if(response && response.data){
                    vm.logs = response.data;
                    $("#log-window").modal("show");
                }
            } , function(error){
                if (error.data){
                    vm.error = error.data.ExceptionMessage;
                }
            });
        }

        function reset() {
            vm.error = "";
            vm.result = "";
        }

        function sum(){
            reset();
            if(vm.number1 === "" || vm.number2 === "") {
                vm.error = "Empty values are not allowed";
                return;
            }
            var promise = numberService.addNumbers(vm.number1,vm.number2);
            promise.then(function(response){
                if(response && response.data){
                    vm.result = vm.number1 + " + " + vm.number2 + " := " + response.data;
                }
            } , function(error){
                if (error.data){
                    vm.error = error.data.ExceptionMessage;
                }
            });
        };
    };
})();