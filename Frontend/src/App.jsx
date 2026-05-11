import { useEffect, useState } from 'react'
import './App.css'

function App() {
  const [candidateName, setCandidateName] = useState('');
  const [candidateBirth, setCandidateBirth] = useState('');
  const [candidatePhone, setCandidatePhone] = useState('');
  const [candidateEmail, setCandidateEmail] = useState('');
  const [searchCandidate, setSearchCandidate] = useState('');

  const [skillName, setSkillName] = useState('');

  const [allCandidates, setAllCandidates] = useState([]);
  const [allSkills, setAllSkills] = useState([]);
  const [selectedSkills, setSelectedSkills] = useState([]);

  const url = 'http://localhost:5290/api'


  useEffect(() => {
    fetch('http://localhost:5290/api/skill').then(res => res.json()).then(data => setAllSkills(data));
  }, []);

  const handleToggleSkills = (skillId) => {
    if(selectedSkills.includes(skillId)){
      setSelectedSkills(selectedSkills.filter(id => id !== skillId))
    }else{
      setSelectedSkills(selectedSkills.concat(skillId));
    }
  }

  const handleCandidateSubmit = (e) => {
    e.preventDefault();

    const candidate = {
      name: candidateName, birthDate: candidateBirth, phoneNumber: candidatePhone, email: candidateEmail
    };
    fetch('http://localhost:5290/api/candidate', {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(candidate)
    }).then(res => res.json())
  }

  const handleSkillSubmit = (e) => {
    e.preventDefault();

    const skill = {
      name: skillName
    };
    fetch('http://localhost:5290/api/skill', {
      method: 'POST',
      headers: {'Content-Type': 'application/json'},
      body: JSON.stringify(skill)
    }).then(res => res.json())
  }

  const handleSearch = () => {
    let searchUrl = `http://localhost:5290/api/candidate/search?name=${searchCandidate}`

    if(selectedSkills.length > 0){
      selectedSkills.forEach(id => {searchUrl+=`&skillIds=${id}`});
    }

    fetch(searchUrl).then(res => res.json()).then(data => setAllCandidates(data));
  }

  const handleClearSearch = () => {
    setSearchCandidate('');
    setSelectedSkills([]);
    setAllCandidates([]);
  }

  return (
    <div>
      <header className='header'>
        <h1>HR Platform</h1>
      </header>
      <div className="forms-container">
        <div className='card'>
          <h2>New candidate</h2>
          <form onSubmit={handleCandidateSubmit} className='form-column'>
            <input className='input' placeholder='Full name' value={candidateName} onChange={e => setCandidateName(e.target.value)}></input>
            <input className='input' type='date' value={candidateBirth} onChange={e => setCandidateBirth(e.target.value)}></input>
            <input className='input' placeholder='Phone number' value={candidatePhone} onChange={e => setCandidatePhone(e.target.value)}></input>
            <input className='input' placeholder='Email' value={candidateEmail} onChange={e => setCandidateEmail(e.target.value)}></input>
            <button className='button' type='submit'>Create</button>
          </form>
        </div>
        <div className='card'>
          <h2>New skill</h2>
          <form onSubmit={handleSkillSubmit}>
            <input className='input' placeholder='Skill name' value={skillName} onChange={e => setSkillName(e.target.value)}></input>
            <button className='button' type='submit'>Create</button>
          </form>
        </div>
      </div>
      <div className='search-container'>
        <div className='skills-container'>
          <p>Filter by name or skills:</p>
          <input className='input' placeholder='Search...' value={searchCandidate} onChange={e => setSearchCandidate(e.target.value)}></input>
          {allSkills.map(s => (
            <label key={s.id}>
              <input type='checkbox' checked={selectedSkills.includes(s.id)} onChange={() => handleToggleSkills(s.id)}></input>
              {s.name}
            </label>
          ))}
          <button className='button' onClick={handleSearch}>Search</button>
          <button className='button' onClick={handleClearSearch}>Clear</button>
        </div>
        <div className='candidates'>
          <p>List of candidates:</p>
          <div className='forms-container'>
            {allCandidates.map(c => (
              <div key={c.id} className='card'>
                <h2>{c.name}</h2>
                <p>Birth date: {c.birthDate}</p>
                <p>Phone: {c.phoneNumber}</p>
                <p>E-mail: {c.email}</p>
              </div>
            ))}
          </div>
        </div>

      </div>
    </div>
  )
}

export default App
