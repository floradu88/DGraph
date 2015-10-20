module DGraph {
    "use strict";

    export class Search {
        private keywords: string;
        private name: string;
        private context: JQuery;
        private $: JQueryStatic;

        constructor(context: JQuery, $: JQueryStatic) {
            this.keywords = "jquery mvc";
            this.name = "jquery";
            this.context = context;
            this.$ = $;

            this.initialize();
        }

        getRequestData(): string {
            var requestData: string = $("#search-form").serialize();

            console.log(requestData);

            return requestData;
        }

        initialize(): void {
            $("#Keywords", this.context).val(this.keywords);
            $("#Name", this.context).val(this.name);

            $("#submit", this.context).on('click', (e) => this.submitSearchForm(e, this));
        }

        submitSearchForm(e, that): boolean {
            var self = that;
            e.preventDefault();
            var data: string = self.getRequestData();
            $.ajax({
                url: "/Search/Search?" + data,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                type: "GET",
                error: (xhr: JQueryXHR, status: string, message: string) => {
                    console.log("something bad happended: " + message);
                }
            }).done((data) => {
                    console.log("Done with the request " + data.Keywords);
                });

            return false;
        }
    }
}