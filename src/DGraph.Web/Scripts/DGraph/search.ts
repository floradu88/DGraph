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

        initialize(): void {
            $("#keywords", this.context).val(this.keywords);
            $("#name", this.context).val(this.name);

            $(this.context).on('submit', this.submitSearchForm);
        }

        getRequestData(): any {
            var requestData: any = {
                keywords: $("#keywords", this.context).val(),
                name: $("#name", this.context).val()
            };

            return requestData;
        }

        submitSearchForm(): boolean {
            $.ajax({
                url: "/Search/Search",
                data: () => this.getRequestData(),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                type: "GET",
                error: (xhr: JQueryXHR, status: string, message: string) => {
                    console.log("something bad happended: " + message);
                }
            }).done(() => {
                    console.log("Done with the request");
                });

            return false;
        }
    }
}