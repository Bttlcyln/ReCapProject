﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarListed = "Arabalar Listelendi";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba Silindi";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomeUpdated = "Müşteri güncellendi";
        public static string RentalAdded = "Kiralama işlemi eklendi";
        public static string RentalDeleted = "Kiralama işlemi silindi";
        public static string RentalUpdated = "Kiralama işlemi güncellendi";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserRegistered = "Kayıt oldu";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string CarImagesListed = "Arabaya ait resimler listelendi.";
        public static string CarImageAdded = "Araba resmi eklendi.";
        public static string CarImageUpdated = "Araba resmi güncellendi.";
        public static string CarImageDeleted = "Araba resmi silindi.";
        public static string CarImageNotFound = "Araba resmi bulunamadı.";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
