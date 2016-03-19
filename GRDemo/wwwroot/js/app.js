function Tab(id, name) {
    this.id = id;
    this.name = ko.observable(name);
    //sample of using an on-demand observable here
    this.details = ko.onDemandObservable(this.getDetails, this);
}

Tab.prototype.getDetails = function() {
    $.ajax({
        type: 'GET',
        url: '/api/values/' + this.id.toString(),
        data: null,
        context: this,
        success: function(data) {
            this.details(data.details);
        },
        dataType: 'json'
    });
};

var viewModel = {
    tabs: ko.observableArray([
        new Tab(1, "5 second delay"),
        new Tab(2, "8 second delay"),
        new Tab(3, "2 second delay")
        ]),
    selectedTab: ko.observable()
};

//select the first tab
viewModel.selectedTab(viewModel.tabs()[0]);

ko.applyBindings(viewModel);