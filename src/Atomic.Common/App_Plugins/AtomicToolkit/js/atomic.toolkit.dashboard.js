angular.module("umbraco").controller("Atomic.ModelsBuilder.Dashboard.Controller", function ($scope, $http) {

    var rebuildModelsUrl = "/Umbraco/backoffice/api/AtomicToolkit/RebuildModels";

    $scope.generateModels = function () {

        $scope.modelsGeneratedRequest = false;
        $http.get(rebuildModelsUrl).then(function (response) {

            var modelsGeneratedSuccess = response.data;

            $scope.modelsGeneratedSuccess = modelsGeneratedSuccess;
            $scope.modelsGeneratedRequest = true;
        });
    }

});