import i18n from 'i18next'
import LanguageDetector from 'i18next-browser-languagedetector'
import { initReactI18next } from 'react-i18next'
import en_US from './resources/en-US.json'
import vi_VN from './resources/vi-VN.json'

i18n.use(LanguageDetector)
    .use(initReactI18next)
    .init({
        fallbackLng: 'en',
        resources:{
            en: en_US,
            vi: vi_VN
        },    
        ns: ["translations"],
        defaultNS: "translations",
        keySeparator: false,
        interpolation:{
            escapeValue: false
        }
    })

export default i18n