If this doesnt look right click: (https://github.com/DawidNieborak/portfolio.api.post-process-server/blob/master/README.md)
<div id="top"></div>
<br/><br/>

## Description

While creating my website, I encountered a problem with the github api, namely one user from a given ip address has a limited number of github access requests in order not to overload the servers and protect against the attack. This background API gets data from github every hour via Hangfire. It then saves the selected data to the MongoDB database. From here I can share data with users without any restrictions. 

Thanks to this, I do not have to update the page every time I create something new. Just publish your project repository, add readme, and this api will do the rest.
<br/><br/>
## Built With

-   c# | ASP.NET CORE
-   Hangfire
-   MongoDB
<br/><br/>
## Author

Dawid Nieborak - dawidnieborak112@gmail.com
<br/><br/>
## License

[Mozilla Public License 2.0](https://choosealicense.com/licenses/mpl-2.0/)
