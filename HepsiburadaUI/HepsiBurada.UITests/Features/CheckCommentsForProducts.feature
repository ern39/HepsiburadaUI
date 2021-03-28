Feature: CheckCommentsForProducts
	Hepsiburada adresine gidilip, ilgili ürün için arama yapılır
	ve aranan ürün için değerlendirmeler görüntülenip, beğenilir


Scenario: CheckCommentsForProducts
    * 'https://www.hepsiburada.com/' sitesine gidilir
	* Arama çubuğundan 'iphone' ürünü aratılır
	* Arama sonucunda gelen ürün listesinden ilk ürün seçilir
	* Ürün detay sayfasından değerlendirmeler tabına tıklanır
	* Yorumların geldiği izlenir aksi halde test bitirilir
	* Sırala dropdown tıklanır
	* Dropdown seçenekleri kontrol edilir
	* Gelen yorumlar arasından ilk yorumun evet butonuna basılır
	* 'Teşekkür Ederiz.' uyarısının geldiği görülür