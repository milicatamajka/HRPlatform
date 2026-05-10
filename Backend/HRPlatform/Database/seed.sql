DELETE FROM "CandidateSkill";
DELETE FROM "Candidates";
DELETE FROM "Skills";

INSERT INTO "Candidates"("Id", "Name", "BirthDate", "PhoneNumber", "Email") VALUES
(1, 'Pera Peric', '1998-05-10', '+381601234567', 'peraperic98@gmail.com'),
(2, 'Mika Mikic', '1990-08-21', '+381619874561', 'mikamikic90@gmail.com'),
(3, 'Jovana Jovanic', '1995-12-15', '+381604561230', 'jovanajovanic95@gmail.com');

INSERT INTO "Skills"("Id", "Name") VALUES
(1, 'C#'),
(2, 'Java'),
(3, 'Python'),
(4, 'Angular'),
(5, 'React');

INSERT INTO "CandidateSkill"("CandidatesId", "SkillsId") VALUES
(1, 1),
(1, 2),
(1, 4),
(2, 1),
(2, 3),
(2, 5),
(3, 1),
(3, 4),
(3, 5);

SELECT setval(pg_get_serial_sequence('"Candidates"', 'Id'), (SELECT COALESCE(MAX("Id"),0) FROM "Candidates"));
SELECT setval(pg_get_serial_sequence('"Skills"', 'Id'), (SELECT COALESCE(MAX("Id"),0) FROM "Skills"));