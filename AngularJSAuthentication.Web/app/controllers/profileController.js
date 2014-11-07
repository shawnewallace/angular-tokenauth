'use strict';
app.controller('profileController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {
	$scope.profile = authService.authentication.profile;
}]);