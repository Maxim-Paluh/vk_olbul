var xhr = new XMLHttpRequest();

var token = "{AppToken}";

var urlListBook = `https://api.vk.com/method/pages.getTitles?group_id=39897717&access_token=${token}&v=5.126`;

xhr.open('GET', urlListBook, false);
xhr.send();
var ListBook = JSON.parse(xhr.responseText);
console.log(`Count book: ${ListBook.response.length}`);
var RetListBook="";
for(var i = 0; i < ListBook.response.length; i++)
{
    var urlBook = `https://api.vk.com/method/pages.get?owner_id=-39897717&page_id=${ListBook.response[i].id}&global=0&site_preview=0&need_source=0&need_html=1&access_token=${token}&v=5.126`;
    xhr.open('GET', urlBook, false);
    xhr.send();
    RetListBook+=xhr.responseText+"\n";
    RetListBook+="<-------------------------------------------------------------------->\n"
    console.log(`Add book id: ${i}`);
    sleep(1000);
}
console.log(RetListBook);

function sleep(milliseconds) {
  const date = Date.now();
  let currentDate = null;
  do {
    currentDate = Date.now();
  } while (currentDate - date < milliseconds);
}