CREATE TABLE utilisateurs (
    id_utilisateur SERIAL PRIMARY KEY,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL,
    mot_de_passe VARCHAR(255) NOT NULL,
    poste VARCHAR(50),
    role VARCHAR(30) DEFAULT 'responsable',
    date_creation TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO utilisateurs (nom, prenom, email, mot_de_passe, poste, role)
VALUES
('Ben Ali', 'Sarra', 'sarra.benali@softavera.tn', 'hashed_pw_admin', 'Chef de projet digital', 'admin'),
('Trabelsi', 'Amine', 'amine.trabelsi@softavera.tn', 'hashed_pw_resp', 'Responsable marketing', 'responsable'),
('Ayari', 'Nada', 'nada.ayari@softavera.tn', 'hashed_pw_analyst', 'Analyste marketing', 'analyste');


CREATE TABLE services (
    id_service SERIAL PRIMARY KEY,
    nom_service VARCHAR(100) NOT NULL,
    prix DECIMAL(10,2),
    description TEXT,
    categorie VARCHAR(50)
);


INSERT INTO services (nom_service, prix, description, categorie)
VALUES
('Création de site vitrine', 1200.00, 'Conception d’un site web professionnel, design responsive.', 'Développement Web'),
('Développement e-commerce', 2500.00, 'Boutique en ligne avec paiement sécurisé et gestion des stocks.', 'Développement Web'),
('Référencement SEO', 900.00, 'Optimisation du positionnement sur Google.', 'Marketing Digital'),
('Campagne Google Ads', 700.00, 'Création et suivi des campagnes publicitaires sur Google.', 'Marketing Digital'),
('Community Management', 800.00, 'Gestion et animation des pages Facebook, Instagram, LinkedIn.', 'Marketing Digital'),
('Design UX/UI', 950.00, 'Création d’interfaces modernes et ergonomiques.', 'Design'),
('Hébergement Web', 400.00, 'Serveurs sécurisés avec certificat SSL.', 'Infrastructure'),
('Maintenance et Support', 600.00, 'Suivi technique, mises à jour et assistance continue.', 'Maintenance');


CREATE TABLE clients (
    id_client SERIAL PRIMARY KEY,
    nom_client VARCHAR(100) NOT NULL,
    secteur VARCHAR(100),
    email_contact VARCHAR(100),
    telephone VARCHAR(20),
    ville VARCHAR(50),
    pays VARCHAR(50) DEFAULT 'Tunisie'
);


INSERT INTO clients (nom_client, secteur, email_contact, telephone, ville)
VALUES
('La Marsa Beauty', 'Cosmétiques', 'contact@lamarsabeauty.tn', '29563214', 'Tunis'),
('TechWave', 'Informatique', 'info@techwave.tn', '22365478', 'Sousse'),
('GoFood', 'Restauration', 'support@gofood.tn', '20215487', 'Sfax');


CREATE TABLE canaux (
    id_canal SERIAL PRIMARY KEY,
    nom_canal VARCHAR(50) NOT NULL,
    description TEXT
);

INSERT INTO canaux (nom_canal, description)
VALUES
('Facebook Ads', 'Campagnes sponsorisées sur Meta (Facebook/Instagram)'),
('Google Ads', 'Annonces sur le moteur de recherche Google'),
('LinkedIn Ads', 'Campagnes B2B pour entreprises'),
('YouTube Ads', 'Vidéos promotionnelles sur YouTube'),
('Emailing', 'Campagnes de newsletters ciblées');


CREATE TABLE campagnes (
    id_campagne SERIAL PRIMARY KEY,
    nom_campagne VARCHAR(100) NOT NULL,
    description TEXT,
    date_debut DATE NOT NULL,
    date_fin DATE NOT NULL,
    budget DECIMAL(12,2),
    objectif VARCHAR(100),
    id_utilisateur INT REFERENCES utilisateurs(id_utilisateur) ON DELETE SET NULL,
    id_canal INT REFERENCES canaux(id_canal) ON DELETE SET NULL,
    id_client INT REFERENCES clients(id_client) ON DELETE CASCADE,
    id_service INT REFERENCES services(id_service) ON DELETE SET NULL,
    statut VARCHAR(20) DEFAULT 'planifiée',
    date_creation TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO campagnes (nom_campagne, description, date_debut, date_fin, budget, objectif, id_utilisateur, id_canal, id_client, id_service, statut)
VALUES
('SEO Local Tunis 2025', 'Optimisation du référencement local pour TechWave.', '2025-03-01', '2025-06-30', 3000.00, 'Atteindre top 3 Google', 1, 2, 2, 3, 'terminée'),
('Campagne Ramadan 2025', 'Publicité Facebook pour GoFood avant le Ramadan.', '2025-02-10', '2025-03-10', 2500.00, 'Augmenter les ventes de 25%', 2, 1, 3, 5, 'en cours'),
('Rebranding La Marsa Beauty', 'Relance de la marque avec design UX et SEO.', '2025-07-01', '2025-09-30', 4500.00, 'Moderniser la présence en ligne', 3, 3, 1, 6, 'planifiée');


CREATE TABLE indicateurs_performance (
    id_indicateur SERIAL PRIMARY KEY,
    id_campagne INT REFERENCES campagnes(id_campagne) ON DELETE CASCADE,
    clics INT DEFAULT 0,
    impressions INT DEFAULT 0,
    ventes INT DEFAULT 0,
    taux_conversion DECIMAL(5,2),
    roi DECIMAL(8,2),
    date_maj TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO indicateurs_performance (id_campagne, clics, impressions, ventes, taux_conversion, roi)
VALUES
(1, 2000, 25000, 180, 9.5, 3.2),
(2, 1500, 20000, 250, 12.5, 4.1),
(3, 800, 12000, 95, 8.0, 2.9);


CREATE TABLE historique_actions (
    id_action SERIAL PRIMARY KEY,
    id_utilisateur INT REFERENCES utilisateurs(id_utilisateur) ON DELETE SET NULL,
    id_campagne INT REFERENCES campagnes(id_campagne) ON DELETE CASCADE,
    type_action VARCHAR(50),
    details TEXT,
    date_action TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO historique_actions (id_utilisateur, id_campagne, type_action, details)
VALUES
(1, 1, 'Création', 'Campagne SEO Local créée pour TechWave.'),
(2, 2, 'Lancement', 'Campagne Ramadan activée sur Facebook.'),
(3, 3, 'Planification', 'Rebranding La Marsa Beauty prévu pour juillet.');



SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';
SELECT COUNT(*) AS nb_services FROM services;
SELECT COUNT(*) AS nb_clients FROM clients;
SELECT COUNT(*) AS nb_campagnes FROM campagnes;

SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';



