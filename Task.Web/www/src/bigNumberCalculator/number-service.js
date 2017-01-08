(function NumberService() {
    angular.module("app").factory("numberService", Service);

    Service.$inject = ["$http","SERVICE_URL"];
    function Service($http,baseUrl){
        var callService = function (methodUrl) {
            return $http({
                url: baseUrl + methodUrl,
                method: 'GET',
                data: '',
                headers: {
                    "Content-Type": "application/json"
                }
            });
        };
        return {
            addNumbers: function (num1, num2) {
                return callService("/AddNumbers/" + num1 + "/" + num2);
            },
            getLogs: function () {
                return callService("/GetAllLogs");
            }
        };
    };
})();

