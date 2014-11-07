'use strict';
app.controller('contactsController', ['$scope', '$location', 'contactsService', function ($scope, $location, contactsService) {
	$scope.contacts = [];

	$scope.contact = {
		first_name: "",
		last_name: "",
		unit: "",
		email: ""
	};

	$scope.message = "";
	$scope.predicate = ['-unit', '-last_name'];

	contactsService.getContacts().then(function (results) {
		$scope.contacts = results.data.data;
	}, function (error) {
		alert(error.data.message);
	});
}]);