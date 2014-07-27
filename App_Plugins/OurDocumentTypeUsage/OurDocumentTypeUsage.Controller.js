angular.module('umbraco.resources').factory('dashResource', function ($http) {
    return {
        get: function () {
            return $http.get(Umbraco.Sys.ServerVariables["ourDocumentTypeUsage"]["ourDocumentTypeUsageApiPathGet"]);
        }
    };
});

angular.module("umbraco").controller("OurDocumentTypeUsageController", function ($scope, notificationsService, dashResource) {
    $scope.listDocumentTypes = [];
    $scope.listDocumentTypesNotInUse = [];

    dashResource.get().then(function (response) {
        $scope.listDocumentTypes = response.data.List;
        $scope.listDocumentTypesNotInUse = response.data.ListDocumentTypesNotInUse;
        $scope.documentTypeCount = response.data.DocumentTypeCount;
        $scope.contentNodeCount = response.data.ContentNodeCount;
    }, function (response) {
        notificationsService.error("Error", "Error loading document types");
        console.log(response.data);
    });
    }
);