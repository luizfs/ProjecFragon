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
    };

    //getProfessionById();
    //function getProfessionById() {
    //    $scope.d = [];
    //    var pathp = $location.path();
    //    var idp = pathp.split("/", 3)[2];
    //    CustomerApi.getCustomersById(2).then(function (d) {
    //        $scope.d.professions = d.d;
    //    }, function (erro) {
    //        $scope.status = 'Unable to load professions data:' + error.message;
    //    })
    //};
});