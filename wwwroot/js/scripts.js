function changeBgImg(){
    var elems = document.getElementsByClassName('filelogo');
    for (var i = 0; i < elems.length; i++) {
        elem = elems[i].innerText.split(' ')
        ext = elem[elem.length - 1].split('.')
        
       // console.log('+++ ', elem);
        console.log('-------- ', ext);
        file_ext = ext[ext.length-1]
        if (file_ext=='pdf'){
            elems[i].style.backgroundImage = "url('/images/fileformat/pdf.svg')";
        }
        else if (file_ext=='txt'){
            elems[i].style.backgroundImage = "url('/images/fileformat/text.svg')";
        }
        else if (file_ext=='doc' || file_ext=='docx' || file_ext=='rtf') {
            elems[i].style.backgroundImage = "url('/images/fileformat/word.svg')";
        }
        else if (file_ext=='xls' || file_ext=='xlsx') {
            elems[i].style.backgroundImage = "url('/images/fileformat/excel.svg')";
        }
        else if (file_ext=='ppt' || file_ext=='pptx') {
            elems[i].style.backgroundImage = "url('/images/fileformat/power-point.svg')";
        }
        else if (file_ext=='png' || file_ext=='bmp' || file_ext=='gif' || file_ext=='jpg') {
            elems[i].style.backgroundImage = "url('/images/fileformat/image-picture.svg')";
        }
        else if (file_ext=='zip' || file_ext=='zip') {
            elems[i].style.backgroundImage = "url('/images/fileformat/power-point.svg')";
        }

        else {
            elems[i].style.backgroundImage = "url('/images/fileformat/power-point.svg')";
        }
	}
}


changeBgImg();
