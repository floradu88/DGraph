module DGraph {
    "use strict";

    export class Search {
        private keywords: string;
        private name: string;
        private page: number;
        private totalPages: number;
        private context: JQuery;
        private $: JQueryStatic;

        constructor(context: JQuery, $: JQueryStatic) {
            this.keywords = "";
            this.name = "";
            this.context = context;
            this.$ = $;
            this.page = 1;
            this.totalPages = 1;

            this.initialize();
        }

        getRequestData(that): string {
            var self = that;
            var requestData: string = $(self.context).serialize();
            return requestData;
        }

        initialize(): void {
            var self = this;
            $("#Keywords", this.context).val(self.keywords);
            $("#Name", this.context).val(self.name);

            $("#submit", this.context).on('click', (e) => self.submitSearchForm(e, self.context));
            $("#results").on('click', "#nextPage", () => self.nextPage(self));
            $("#results").on('click', "#prevPage", () => self.prevPage(self));
        }

        prevPage(self): void {
            if (self.page > 1) {
                self.page--;
                self.search(self.context);
            }
        }

        nextPage(self): void {
            if (self.page < self.totalPages) {
                self.page++;
                self.search(self.context);
            }
        }

        submitSearchForm(e: any, context: JQuery): boolean {
            var self = this;
            e.preventDefault();
            self.search(context);

            return false;
        }

        search(context: JQuery): void {
            var self = this;
            var data: string = self.getRequestData(context);
            $.ajax({
                url: "/Search/Search?" + data,
                contentType: "text/html",
                dataType: "text",
                async: true,
                type: "GET",
                error: (xhr: JQueryXHR, status: string, message: string) => {
                    console.log("something bad happended: " + message);
                }
            }).done((result) => {
                    if (result !== null)
                        $("#results").html(result);
                });
        }
    }
}