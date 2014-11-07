'use strict';
app.factory('contactsService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {
	
	var serviceBase = ngAuthSettings.apiServiceBaseUri;
	var contactsServiceFactory = {};

	var _getContacts = function () {
		return $http.get(serviceBase + 'api/contacts').then(function (results) {
			return results;
		});
	};
	
	contactsServiceFactory.getContacts = _getContacts;
	return contactsServiceFactory;
}]);