MyApp.controller("DetailsCustomersController", function ($scope, CustomerApi, $location) {
    getCustomersById();
    function getCustomersById() {
        $scope.data = [];
        var path = $location.path();
        var id = path.split("/", 3)[2];
        CustomerApi.getCustomersById(id).then(function (data) {
            $scope.data.customers = data.data;
        }, function (error) {
            $scope.status = 'Unable to load customers data: ' + error.message;
        })            
    }
});